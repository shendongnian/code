    public class SomeGUI extends JFrame implements ActionListener {
    
        protected JButton button1;
        protected JButton button2;
        //...
        protected JButton buttonN;
    
        public void actionPerformed(ActionEvent e) {
            if (e.getSource() == button1) {
            // do something
            } else if (e.getSource() == button2) {
                //... you get the picture
            }
        }
    }
