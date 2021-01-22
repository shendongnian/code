    class ConvolutedBusinessLogic
    {
        public void Splork(MyWidget widget)
        {
            if (widget.Validate())
            {
                widgetRepository.Save(widget);
                widget.LastSaved = DateTime.Now;
                OnSaved(new WidgetSavedEventArgs(widget));
            }
            else
            {
                Log.Error("Could not save MyWidget due to a validation error.");
                SendEmailAlert(new WidgetValidationAlert(widget));
            }
        }
    }
