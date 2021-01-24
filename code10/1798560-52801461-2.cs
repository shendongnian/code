    public static void Main()
        {
            scheduleTick(100, someEvent(new object[]() {"some args"})
            /* this will not complile. you are passing `void` to method `handleScheduledTicks` as an argument to type of TickEvent. It should be like :
               scheduleTick(100, someEvent) */
    
            while(true)
            {
                handleScheduledTicks();
                ticks++;
            }
        }
