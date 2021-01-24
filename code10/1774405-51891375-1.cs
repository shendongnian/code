    public class Functions
     {
          public static void CronJob([TimerTrigger("0 */5 * * * *")] TimerInfo timer)
            {
                Console.WriteLine("timer job fired!");
            }
      }
