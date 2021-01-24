     public class yourFruitStand
     {
          private string yourFruitName;
          public bool YourFruitName
          {
               get
               {
                   return yourFruitName;
               }
               set
               {
                   yourFruitName = value;
                   if(yourFruitName == "apple")
                   {
                        yesOrNo = true;
                   }
                   else
                   {
                        yesOrNo = false;
                   }
               }
          }
          private bool yesOrNo;
          public bool yesOrNo
          {
               get
               {
                   return yesOrNo;
               }
               set
               {
                   yesOrNo = value;
               }
          }
     }
