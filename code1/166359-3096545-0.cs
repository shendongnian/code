    public class YourClass {
        public static void main( String [] args ) {  
              String param = "someDefault";
              // validate args.length 
              if( args.length > 0 ) { // if there is a parameter
                  param = args[0]; // use it 
              }
              // continue with "param" already defined.
        }
     }
