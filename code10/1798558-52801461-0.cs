    public static void Main()
        {
            scheduleTick(100, someEvent(new object[]() {"some args"})
            /* this will not complile. it should be like :
               scheduleTick(100, someEvent) */
    
            while(true)
            {
                handleScheduledTicks();
                ticks++;
            }
        }
