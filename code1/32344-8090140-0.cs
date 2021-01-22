       public void publish(dynamic queue)
         {
             publish(queue);
             Console.WriteLine("dynamic queue publishing");
         }
         
         public void publish(ValidationQueue queue)
         {
             Console.WriteLine("Validation queue publishing");
         }
