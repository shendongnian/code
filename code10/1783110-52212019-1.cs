    this.NavigationController.Delegate = new NavigationControllerDelegate();
     public class NavigationControllerDelegate : UINavigationControllerDelegate
    {
        public NavigationControllerDelegate(IntPtr handle) : base(handle)
        {
        }
        public NavigationControllerDelegate()
        {
        }
        public override IUIViewControllerAnimatedTransitioning GetAnimationControllerForOperation(UINavigationController navigationController, UINavigationControllerOperation operation, UIViewController fromViewController, UIViewController toViewController)
        {
            var fromVcConformA = fromViewController as ICustomTransition;
            var fromVCConFromB = fromViewController as IWaterFallViewControllerProtocol;
            var fromVCCConformc = fromViewController as IHorizontalPageViewControllerProtocol;
            var toVcConformA = toViewController as ICustomTransition;
            var toVCConfromB = toViewController as IWaterFallViewControllerProtocol;
            var toVCCConformc = toViewController as IHorizontalPageViewControllerProtocol;
            if ((fromVcConformA != null) && (toVcConformA != null) && ((fromVCConFromB != null && toVCCConformc != null) || (fromVCCConformc != null && toVCConfromB != null)))
            {
                var transition = new CustomTransition();
                transition.presenting = operation == UINavigationControllerOperation.Pop;
                return transition;
            }
            else
            {
                return null;
            }
        }
    }
