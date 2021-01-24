     namespace Houses {
       public static class TV {
         public static bool isOn;
         public static void SetOn(){
           //do stuff to set attribute isOn
         }
       }
     }
     ...
     namespace Houses {
       public class House {
         public void CheckTV() {
           TV.SetOn();
         }
       }
     }
