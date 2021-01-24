        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
    
                var listView = Control as UITableView;
                listView.SeparatorInset = UIEdgeInsets.Zero;
                this.Control.TableFooterView = new UIView();
            }
            var element = (your Interface name here / Control which you want to render)this.Element;
            //afterwards you can Access your Properties from **element** Like,
            element.ShowExtraCells = true;
        }
