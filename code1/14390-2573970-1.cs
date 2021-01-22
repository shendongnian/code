public static IEnumerable&lt;int> Range( int min, int max )
{
   while ( true )
   {
      if ( min >= max )
      {
         yield break;
      }
      yield return min++;
   }
}
