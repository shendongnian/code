    public class YouTryTables : MonoBehaviour 
    {
        // TODO: This variable isn't used
        int n = 1;
        public Text x1, x2, x3, x4, x5, x6, x7, x8, x9, x10;
        // TODO: These variables aren't used
        public int ans1, ans2, ans3, ans4, ans5, ans6, ans7, ans8, ans9, ans10;
        public InputField[] allInputFields = new InputField[10]; //array of user Answers entered in input fields
        public int[] allAnswers = new int[10];//array of correct answers
    
        public void GenerateTable(int n)
        {
            // TODO: Doesn't need .ToString();, they're already strings
            x1.text = (n + "  X  " + 1 + "    = ").ToString();
            x2.text = (n + "  X  " + 2 + "    = ").ToString();
            x3.text = (n + "  X  " + 3 + "    = ").ToString();
            x4.text = (n + "  X  " + 4 + "    = ").ToString();
            x5.text = (n + "  X  " + 5 + "    = ").ToString();
            x6.text = (n + "  X  " + 6 + "    = ").ToString();
            x7.text = (n + "  X  " + 7 + "    = ").ToString();
            x8.text = (n + "  X  " + 8 + "    = ").ToString();
            x9.text = (n + "  X  " + 9 + "    = ").ToString();
            x10.text = (n + "  X  " + 10 + "  = ").ToString();
    
    
    
            for (int i = 0; i < allInputFields.Length; i++)
            {
                // You loop though all 10 arrays but you assign the same component every time; the one on the GameObject you call MyObjectWithInputField
                // You need to get the InputField from the correct GameObjects. Maybe you want to do this in a `public GameObject inputGameObjects` instead?
                // TODO: Get InputField from correct GameObject
                GameObject obj = GameObject.Find("MyObjectWithInputField");
                allInputFields[i] = obj.GetComponent<InputField>();
            }
    
            for (int j = 0; j < allAnswers.Length; j++)
            {
                // TODO: ans1 isn't set yet, but you don't need to save it to a variable first, you can
                // simply do allAnswers[j] = n * (j + 1);
                allAnswers[j] = ans1; 
            }
    
            // TODO: You can remove this if you did allAnswers[j] = n * (j + 1); above
            ans1 = (n * 1);
            ans2 = (n * 2);
            ans3 = (n * 3);
            ans4 = (n * 4);
            ans5 = (n * 5);
            ans6 = (n * 6);
            ans7 = (n * 7);
            ans8 = (n * 8);
            ans9 = (n * 9);
            ans10 = (n * 10);
        }
    
        // TODO: Typo Comapr -> Compare
        // I changed this method to return a bool if all answers were correct
        public bool ComaprAnswers()
        {
            bool allAnswersCorrect = true;
    
            // TODO: You want to loop through all questions here
            // for (int i = 0; i < allInputFields.Length; i++)
            // TODO: You're comparing string to int, allAnswers should be set to string[] and its setters be made .ToString()
            if (allInputFields[i] == allAnswers[j])
            {
                Text text = allInputFields.transform.Find("Text").GetComponent<Text>();
                text.color = Color.green;
            }
            else
            {
                Text text = allInputFields.transform.Find("Text").GetComponent<Text>();
                text.color = Color.red;
                allAnswersCorrect = false;
            }
    
            return allAnswersCorrect;
        }
    }
