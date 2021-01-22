    public class ValidationManager
    {
        /// <summary>
        /// Call this method to validate all controls of the given control list 
        /// Validating event will be called on each one
        /// </summary>
        /// <param name="controls"></param>
        /// <returns></returns>
        public static bool HasValidationErrors(System.Windows.Forms.Control.ControlCollection controls)
        {
            bool hasError = false;
            // Now we need to loop through the controls and deterime if any of them have errors
            foreach (Control control in controls)
            {
                // check the control and see what it returns
                bool validControl = IsValid(control);
                // If it's not valid then set the flag and keep going.  We want to get through all
                // the validators so they will display on the screen if errorProviders were used.
                if (!validControl)
                    hasError = true;
                // If its a container control then it may have children that need to be checked
                if (control.HasChildren)
                {
                    if (HasValidationErrors(control.Controls))
                        hasError = true;
                }
            }
            return hasError;
        }
        /// <summary>
        /// Attach all youe Validating events to this event handler (if the controls requieres validation)
        /// A method with name Validate + PropertyName will be searched on the binded business entity, and if found called
        /// Throw an exception with the desired message if a validation error is detected in your method logic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void ValidationHandler(object sender, CancelEventArgs e)
        {
            BaseEdit control = sender as BaseEdit;
            if (control.DataBindings.Count > 0) //control is binded
            {
                string bindedFieldName = control.DataBindings[0].BindingMemberInfo.BindingField;
                object bindedObject = control.BindingManager.Current;
                if (bindedObject != null) //control is binded to an object instance
                {
                    //find and call method with name = Validate + PropertyName
                    MethodInfo validationMethod = (from method in bindedObject.GetType().GetMethods()
                                                   where method.IsPublic &&
                                                         method.Name == String.Format("Validate{0}",bindedFieldName) &&
                                                         method.GetParameters().Count() == 0
                                                   select method).FirstOrDefault();
                    if (validationMethod != null) //has validation method
                    {
                        try
                        {
                            validationMethod.Invoke(bindedObject, null);
                            control.ErrorText = String.Empty; //property value is valid
                        }
                        catch (Exception exp)
                        {
                            control.ErrorText = exp.InnerException.Message;
                            e.Cancel = true;
                        }
                    }
                }
            }
        }
        // Here, let's determine if the control has a validating method attached to it
        // and if it does, let's execute it and return the result
        private static bool IsValid(object eventSource)
        {
            string name = "EventValidating";
            Type targetType = eventSource.GetType();
            do
            {
                FieldInfo[] fields = targetType.GetFields(
                     BindingFlags.Static |
                     BindingFlags.Instance |
                     BindingFlags.NonPublic);
                foreach (FieldInfo field in fields)
                {
                    if (field.Name == name)
                    {
                        EventHandlerList eventHandlers = ((EventHandlerList)(eventSource.GetType().GetProperty("Events",
                            (BindingFlags.FlattenHierarchy |
                            (BindingFlags.NonPublic | BindingFlags.Instance))).GetValue(eventSource, null)));
                        Delegate d = eventHandlers[field.GetValue(eventSource)];
                        if ((!(d == null)))
                        {
                            Delegate[] subscribers = d.GetInvocationList();
                            // ok we found the validation event,  let's get the event method and call it
                            foreach (Delegate d1 in subscribers)
                            {
                                // create the parameters
                                object sender = eventSource;
                                CancelEventArgs eventArgs = new CancelEventArgs();
                                eventArgs.Cancel = false;
                                object[] parameters = new object[2];
                                parameters[0] = sender;
                                parameters[1] = eventArgs;
                                // call the method
                                d1.DynamicInvoke(parameters);
                                // if the validation failed we need to return that failure
                                if (eventArgs.Cancel)
                                    return false;
                                else
                                    return true;
                            }
                        }
                    }
                }
                targetType = targetType.BaseType;
            } while (targetType != null);
            return true;
        }
    }
