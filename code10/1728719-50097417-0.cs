    public class DetailCell : UICollectionViewCell
    {
        CustomEventHandler HandlerForButton;
        public override void PrepareForReuse ()
        {
            base.PrepareForReuse ();
            if (HandlerForButton != null)
            {
                EditButton.TouchUpInside -= ButtonPressed;
            }
            HandlerForButton = null;
        }
        private void ButtonPressed (object sender, EventArgs args)
        {
            if (HandlerForButton != null)
            {
                HandlerForButton (this, args);
            }
        }
        internal void GetCell (int position, CustomEventHandler handler)
        {
            HandlerForButton = handler;
            EditButton.TouchUpInside += ButtonPressed;
        }
    }
    public class CollectionViewSource : UICollectionViewSource
    {
        public override UICollectionViewCell GetCell (UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = collectionView.DequeueReusableCell ("DetailCell", null) as DetailCell;
            cell.GetCell (indexPath.Row, ClickHandler);
            return cell;
        }
         private void ClickHandler (UICollectionViewCell sender, CustomEventArgs args)
        {
            var cell = sender as UICollectionViewCell;
            if (cell != null)
            {
                // do stuff
            }
            var yourArgs = args as CustomEventArgs;
            if (yourArgs != null)
            {
                // do stuff
            }
        }
    }
    internal delegate void CustomEventHandler (DetailCell sender, CustomEventArgs args);
