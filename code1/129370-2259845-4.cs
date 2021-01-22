    public class IfElseTernaryTest
    {
        private bool bigX;
        public void RunIfElse()
        {
            int x = 4; int y = 5;
            if (x &gt; y) bigX = false;
            else if (x &lt; y) bigX = true; 
        }
        public void RunTernary()
        {
            int x = 4; int y = 5;
            bigX = (x &gt; y) ? false : ((x &lt; y) ? true : false);
        }
    }
