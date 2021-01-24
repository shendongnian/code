    protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
            {
                base.OnElementChanged(e);
    
                if (this.Control != null)
                {
                    var slider = (MySlider)this.Element;
    
                    this.Control.TickMark = Resources.GetDrawable(Resource.Drawable.Icon);//works by setting whole slider image
                    //this.Control.SetThumb(Resources.GetDrawable(Resource.Drawable.Icon));//works by setting thumbnail movable image
    
                    Control.Max = (int)(slider.Maximum - slider.Minimum);//shows RHS value plus one
                    Control.Progress = (int)slider.Value;
                }
            }
