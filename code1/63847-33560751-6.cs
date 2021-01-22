        interface A
            {
               // display()
            }
           
    
         interface B
            {
              //display()
            }
        
         class C implements A,B
            {
               //main()
               C object = new C();
               (A)object.display();     // call A's display
               (B)object.display(); //call B's display
            }
        }
          
    
              
        
              
