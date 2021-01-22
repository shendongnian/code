    public class SomeGUI extends JFrame
    {
       ... button member declarations ...
       protected void buildGUI()
       {
          button1 = new JButton();
          button2 = new JButton();
          ...
          button1.addActionListener(
             new java.awt.event.ActionListener()
             {
                public void actionPerformed(java.awt.event.ActionEvent e)
                {
                   // do something
                }
             }
          );
          .. repeat for each button
