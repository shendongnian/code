    class MyClass
    {
        public static float MaxDepthInches = 3;
        private void PickNose()
        {
            if (CurrentFingerDepth < MyClass.MaxDepthInches)
            {
                CurrentFingerDepth++;
            }
        }
    }
