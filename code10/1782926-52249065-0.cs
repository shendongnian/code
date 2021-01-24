    public void SetTextContainerSize(string fit, float dimension = 0)
        {
            if (UIElement.GetComponent<ContentSizeFitter>() == null)
                UISizeFitterComponent = UIElement.AddComponent(typeof(ContentSizeFitter)) as ContentSizeFitter;
            if (fit == "autoWH")
            {
                UISizeFitterComponent.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
                UISizeFitterComponent.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
                base.SetDimensions( RectOptions.sizeDelta);
            }
            else if (fit == "autoW")
            {
                UISizeFitterComponent.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
                UISizeFitterComponent.verticalFit = ContentSizeFitter.FitMode.Unconstrained;
                Canvas.ForceUpdateCanvases();
                base.SetDimensions( new Vector2(RectOptions.rect.width, dimension));
            }
            else if (fit == "autoH")
            {
                UISizeFitterComponent.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
                UISizeFitterComponent.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
                Canvas.ForceUpdateCanvases();
                base.SetDimensions( new Vector2(dimension, RectOptions.rect.height));
            }
        }
