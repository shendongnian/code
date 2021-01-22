    public class Simulation1
    {
        private SimulationForm form;
        public void Simulation1()
        {
            form = new SimulationForm();
            form.Init = Init;
            form.Render = Render;
            form.Move = Move;
        }
        private void Init()
        {
            // Do Init code here
        }
        private void Render(Graphics g)
        {
            // Do Rendering code here
        }
        private void Move(double dt)
        {
            // Do Move code here
        }
    }
