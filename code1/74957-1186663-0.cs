Public Class Father
{
   private Child _Child=null;
   public Child Child
   {
       get{
           if(_Child==null) _Child=new Child();
           return _Child;
          }
   }
}
Public Class Child
{
     Public void StudyLessons()
     {
       .....
     }
      
}
