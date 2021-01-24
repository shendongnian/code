        public interface ILoginView: IDisposable
        {
            string Login {get; set;}
            string Pass {get; set;}
            DialogResult ShowDialog();
        }
    
