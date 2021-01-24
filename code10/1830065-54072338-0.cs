     public class Initialize : MonoBehaviour
     {
        Question[] questions;
        void Start()
        {
           questions = new Question[2];
           questions[0] = new Question();
           questions[0].fact = "First Question";
           questions[1] = new Question();
           questions[1].fact = "Second Question";
        }
    }
