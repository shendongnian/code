    class TestHelper
    {
        public void HelperMethod()
        {
            string CurrentTestFixture;
            string CurrentTest;
    
            var callingFrame = new StackFrame(1);
            var method = callingFrame.GetMethod();
            CurrentTest = method.Name;
            var type = method.DeclaringType;
            CurrentTestFixture = type.Name;
    
            var relativePath = Path.Combine(CurrentTestFixture, CurrentTest);
            Directory.Delete(Path.Combine(Configurator.LogPath, relativePath));
        }
    }
