    private void ApplyPositionAttribute<T>(AdwizaWebControl webControl) where T : InheritedClass
    {
        /* ... */
    
        T adwizalControl = (T)webControl;
        pageViewrepeatbox.Attributes.Add(
            "style", string.Format("position:absolute;top:{0}px;left:{1}px;", pageViewrepeatbox.Y + increaseY, pageViewrepeatbox.X + increaseX));
        pageView.Controls.Add(pageViewrepeatbox);
    }
