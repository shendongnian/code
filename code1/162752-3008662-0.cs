    interface IThing {
    }
    #if PLATFORM_A
    class ThingImplementation : IThing {
    }
    #endif
    #if PLATFORM_B
    class ThingImplementation : IThing {
    }
    #endif
