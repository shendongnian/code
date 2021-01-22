      public class ValidationHelper : DependencyObject
      {
        [ThreadStatic]
        static List<DependencyObject> _objectsNeedingValidationUpdate;
    
        public static ControlTemplate GetErrorTemplate(DependencyObject obj) { return (ControlTemplate)obj.GetValue(ErrorTemplateProperty); }
        public static void SetErrorTemplate(DependencyObject obj, ControlTemplate value) { obj.SetValue(ErrorTemplateProperty, value); }
        public static readonly DependencyProperty ErrorTemplateProperty = DependencyProperty.RegisterAttached("ErrorTemplate", typeof(ControlTemplate), typeof(ValidationHelper), new FrameworkPropertyMetadata
        {
          Inherits = true,
          PropertyChangedCallback = (obj, e) =>
            {
              if(e.NewValue)
                if(_objectsNeedingValidationUpdate!=null)
                  _objectsNeedingValidationUpdate.Add(obj);
                else
                {
                  _objectsNeedingValidationUpdate = new List<DependencyObject>();
                  _objectsNeedingValidationUpdate.Add(obj);
                  Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Render, new Action(UpdateValidations));
                }
            },
        });
    
        static void UpdateValidations()
        {
          List<DependencyObject> objects = _objectsNeedingValidationUpdate;
          _objectsNeedingValidationUpdate = null;
          if(objects!=null)
            foreach(DependencyObject obj in objects)
              UpdateValidations(obj);
        }
        static void UpdateValidations(DependencyObject obj)
        {
          // My regular code uses obj.GetLocalValueEnumerator here, but that would require some other complexity
          if(UpdateValidations(obj, TextBox.TextProperty))
            if(Validation.GetErrorTemplate(obj)==null)
              Validation.SetErrorTemplate(obj, ValidationHelper.GetErrorTemplate(obj));
        }
        static bool UpdateValidations(DependencyObject obj, DependencyProperty prop)
        {
          var binding = BindingOperations.GetBinding(obj, prop);
          if(binding!=null &&
            binding.Mode==BindingMode.TwoWay &&
            !binding.ValidationRules.Any(rule => rule is ExceptionValidationRule))
          {
            binding.ValidationRules.Add(new ExceptionValidationRule());
            BindingOperations.SetBinding(obj, prop, binding);  // Required to get new rule to work
            return true;
          }
          return false;
        }
      }
