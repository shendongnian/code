    public partial class AudioViewCell : ViewCell
    {
        // ...
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            // * I'm not sure if it's ok create a new instance to your binding context here, the old one ca be kept on memory due it's subscription. Think about create a method to set just the Audiofile property
            slRoot.BindingContext = new MenuItemViewModel( thing, thing, ((GenericSelectableItem<AudioFile>)BindingContext).Data); 
        }
        // ...
    }
    
