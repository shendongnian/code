public class Controller
{
   List<Range> m_positions = new List<Range>();
   public void LoadPositions()
   {
      m_positions.Add(new Range(0, 9));
      m_positions.Add(new Range(10, 19));
      m_positions.Add(new Range(20, 29));
   }
   public int GetPosition (int signal)
   {
      Range range = m_positions.Single(a => IsBetween(signal, a.Min, a.Max));
      return m_positions.IndexOf(range);
   }
   private static bool IsBetween (int target, int min, int max)
   {
      return min <= target && max >= target;
   }
}
