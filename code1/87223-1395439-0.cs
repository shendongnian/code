       public struct Response
       {
         private int ival;
         private Response() {} // private ctor to eliminate instantiation
         private Response(int val) { ival = val; }
         private static readonly Response Yes = new Response(1);
         private static readonly Response No = new Response(2);
         private static readonly Response Maybe= new Response(3);
         // etc...  ...for whatever other functionality you want.... 
       }
