private string mName;
public string Name
{
   get
   {
      return mName;
   }
   set
   {
      if ( value != mName )
      {
           mName = value;
      }
   }
}
