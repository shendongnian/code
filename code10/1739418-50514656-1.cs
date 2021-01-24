    public delegate void ShowFrm();
    public partial class Camera : Form
    {
        
        public event ShowFrm eventForm;
        private void Camera_FormClosing(object sender, FormClosingEventArgs e)
        {
            eventForm?.Invoke();
        }
    }
