    abstract class Controller
    {
       public function __get($key)
       {
           //check to make sure key is ok for item such as View,Library etc
    
           return Registry::get($key); //Object / Null
       }
    }
