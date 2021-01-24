    public void SetTextContainerSize(string fit, float dimension = 0)
		{
			if (UIElement.GetComponent<ContentSizeFitter>() == null)
				UISizeFitterComponent = UIElement.AddComponent(typeof(ContentSizeFitter)) as ContentSizeFitter;
			if (fit == "autoWH")
			{
				UISizeFitterComponent.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
				UISizeFitterComponent.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
			}
			else if (fit == "autoW")
			{
				base.SetDimensions(new Vector2(dimension, dimension));
				UISizeFitterComponent.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
				UISizeFitterComponent.verticalFit = ContentSizeFitter.FitMode.Unconstrained;
				Canvas.ForceUpdateCanvases();
				base.SetDimensions( new Vector2(RectOptions.rect.width, dimension));
			}
			else if (fit == "autoH")
			{
				base.SetDimensions(new Vector2(dimension, dimension));
				UISizeFitterComponent.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
				UISizeFitterComponent.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
				Canvas.ForceUpdateCanvases();
				base.SetDimensions( new Vector2(dimension, RectOptions.rect.height));
			}
		}
