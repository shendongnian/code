    public static IUnityContainer InstallCoreExtensions(this IUnityContainer container)
    {
        container.RemoveAllExtensions();
        container.AddExtension(new UnityClearBuildPlanStrategies());
        container.AddExtension(new UnitySafeBehaviorExtension());
    #pragma warning disable 612,618 // Marked as obsolete, but Unity still uses it internally.
        container.AddExtension(new InjectedMembers());
    #pragma warning restore 612,618
        container.AddExtension(new UnityDefaultStrategiesExtension());
        return container;
    }
