    public abstract class Thing
    {
        private class LightThing : Thing
        { ... }
        private class HeavyThing : Thing 
        { ... }
        public static Thing MakeThing(whatever) 
        { /* make a heavy or light thing, depending */ }
        ... etc ...
    }
