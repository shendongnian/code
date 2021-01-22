public class SomeCharPos{
   private char ch;
   private int row, col;
   public SomeCharPos(char ch, int row, int col){
      this.ch = ch;
      this.row = row;
      this.col = col;
   }
   public char SomeChar{
      get{ return this.ch; }
   }
   public int Row{
      get{ return this.row; }
   }
   public int Col{
      get{ return this.col; }
   }
}
public class DemoIt{
   public Dictionary<char, SomeCharPos> thisDict = new Dictionary<char, SomePos>();
   public DemoIt(){
       thisDict.Add('a', new SomeCharPos('a', 1, 1));
       thisDict.Add('b', new SomeCharPos('a', 2, 1));
       thisDict.Add('c', new SomeCharPos('a', 3, 1));
          ....
       thisDict.Add('x', new SomeCharPos('x', 1, 3));
       thisDict.Add('y', new SomeCharPos('x', 2, 3));
       thisDict.Add('z', new SomeCharPos('x', 3, 3));
   }
   public void DrawIt(){
       foreach (SomeCharPos pos in thisDict.Values){
          Console.SetCursorPosition(pos.Col, pos.Row);
          Console.Write(pos.SomeChar);
       }
   }
}
