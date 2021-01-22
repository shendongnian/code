    FieldInfo extensionsField = container.GetType().GetField("extensions", BindingFlags.Instance | BindingFlags.NonPublic);
    List<UnityContainerExtension> extensionsList = (List<UnityContainerExtension>)extensionsField.GetValue(container);
    UnityContainerExtension[] existingExtensions = extensionsList.ToArray();
    container.RemoveAllExtensions();
    container.AddExtension(new UnityClearBuildPlanStrategiesExtension());
    container.AddExtension(new UnitySafeBehaviorExtension());
    foreach (UnityContainerExtension extension in existingExtensions)
    {
       if (!(extension is UnityDefaultBehaviorExtension))
       {
           container.AddExtension(extension);
       }
    }
