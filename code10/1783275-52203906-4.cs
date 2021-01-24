    class BAble : AAble, IAble
    {
        // Now it compiles
        void IAble.f()
        {
            Console.WriteLine("---->> B - Able");
        }
    }
