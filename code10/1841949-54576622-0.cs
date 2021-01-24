    public abstract class BaseViewController : UIViewController {
        protected virtual void Finished() { }
 
        protected virtual void backPressed() { } //this is just in case I wish to be notified when the user moves back
        public override void ViewWillDisappear(bool animated) {
            base.ViewWillDisappear(animated);
            if (NavigationController != null && NavigationController.ViewControllers.ToList().FirstOrDefault(c => c == this) == null) {
                backPressed();
                Finished();
            }
        }
        public override void DismissViewController(bool animated, [BlockProxy(typeof(AdAction))] Action completionHandler) {
            base.DismissViewController(animated, completionHandler);
            Finished();
        }
        public void Present(string storyboard, bool replace = false, bool animated = true) {
            UIViewController vctl = UIStoryboard.FromName(storyboard, null).InstantiateInitialViewController();
            if (replace) {
                List<UIViewController> old = new List<UIViewController>();
                if (UIApplication.SharedApplication.KeyWindow.RootViewController is UINavigationController nav) {
                    old.AddRange(nav.ViewControllers);
                } else {
                    old.Add(UIApplication.SharedApplication.KeyWindow.RootViewController);
                }
                if (animated) {
                    UIView.Transition(
                        UIApplication.SharedApplication.KeyWindow
                        , 0.25
                        , UIViewAnimationOptions.TransitionCrossDissolve
                        , () => UIApplication.SharedApplication.KeyWindow.RootViewController = vctl
                        , () => {
                            old.ForEach(o => (old as BaseViewController)?.Finished());
                        });
                } else {
                    UIApplication.SharedApplication.KeyWindow.RootViewController = vctl;
                    old.ForEach(o => (old as BaseViewController)?.Finished());
                }
            } else {
                this.PresentViewController(vctl, animated, null));
            }
        }
        public void AddController(string storyboard, string controller = null, bool animated = true) {
            UIViewController ctl = getController(storyboard, controller);
            this.NavigationController?.PushViewController(ctl, animated);
        }
        public static void ReplaceController(this UINavigationController me, string storyboard, string controller = null, bool animated = true) {
            UIViewController ctl = getController(storyboard, controller);
            UIViewController[] vcl = this.NavigationController?.ViewControllers;
            if (vcl == null) return;
            if (vcl.Length > 0) {
                UIViewController old = vcl[vcl.Length - 1];
                vcl[vcl.Length - 1] = ctl;
                me.SetViewControllers(vcl, animated);
                (old as BaseViewController)?.Finished();
            } else {
                me.PushViewController(ctl, animated);
            }
        }
        private UIViewController getController(string storyboard, string controller = null) {
            if (string.IsNullOrWhiteSpace(controller)) {
                return UIStoryboard.FromName(storyboard, null).InstantiateInitialViewController();
            }
            return UIStoryboard.FromName(storyboard, null).InstantiateViewController(controller);
        }
    }
