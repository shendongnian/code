        var extensionsField = container.GetType().GetField("extensions", BindingFlags.Instance | BindingFlags.NonPublic);
        var extensionsList = (List<UnityContainerExtension>)extensionsField.GetValue(container);
        var existingExtensions = extensionsList.ToArray();
        container.RemoveAllExtensions();
        container.AddExtension(new UnitySafeBehaviorExtension());
        foreach (var extension in existingExtensions)
        {
            if (!(extension is UnityDefaultBehaviorExtension))
            {
                container.AddExtension(extension);
            }
        }
    }
