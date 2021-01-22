    //in CreateDescription() modify
    
    if (serviceEndpoint.Binding == null)
    
                   {
    
                       serviceEndpoint.Binding = CreateBinding(selectedEndpoint.Binding, selectedEndpoint.BindingConfiguration, serviceModeGroup);
    
                   }
    
    ...
    
      if (serviceEndpoint.Behaviors.Count == 0 && !String.IsNullOrEmpty(selectedEndpoint.BehaviorConfiguration))
    
                   {
    
                       AddBehaviors(selectedEndpoint.BehaviorConfiguration, serviceEndpoint, serviceModeGroup);
    
                   }
    
      /// <summary>
    
           /// Configures the binding for the selected endpoint
    
           /// </summary>
    
           /// <param name="bindingName"></param>
    
           /// <param name="group"></param>
    
           /// <returns></returns>
    
           private Binding CreateBinding(string bindingName, string bindingConfiguration, ServiceModelSectionGroup group)
    
           {
    
               IBindingConfigurationElement be = null;
    
               BindingCollectionElement bindingElementCollection = group.Bindings[bindingName];
    
               if (bindingElementCollection.ConfiguredBindings.Count > 0)
    
               {
    
                   foreach (IBindingConfigurationElement bindingElem in bindingElementCollection.ConfiguredBindings)
    
                   {
    
                       if (string.Compare(bindingElem.Name, bindingConfiguration) == 0)
    
                       {
    
                           be = bindingElem;
    
                           break;
    
                       }
    
                   }
    
                   Binding binding = null;
    
                   if (be != null)
    
                   {
    
                       binding = GetBinding(be);
    
                       be.ApplyConfiguration(binding);
    
                   }
    
                   return binding;
    
               }
    
               return null;
    
           }
