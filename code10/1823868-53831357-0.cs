    public class PlayerController : MonoBehaviour {
        private float movementDuration = 2.0f;
        private float waitBeforeMoving = 2.0f;
        private Vector3[] v = new Vector3[20];
        //StreamWriter file = new StreamWriter("output.txt",true);
        void Start()
        {
            this.MoveToPoints();
            this.PrintPoints();
        }
        private void MoveToPoints()
        {
            for (int i = 0; i < v.Length; i++)
            {
                float timer = 0.0f;
                Vector3 startPos = transform.position;
                float x = this.RandomNum(timer);
                float y = this.RandomNum(x);
                float z = this.RandomNum(y);
                v[i] = new Vector3(x, y, z);
                while (timer < movementDuration)
                {
                    timer += Time.deltaTime;
                    float t = timer / movementDuration;
                    t = t * t * t * (t * (6f * t - 15f) + 10f);
                    transform.position = Vector3.Lerp(startPos, v[i], t);
                    yield return null;
                }
            }
        }
        void PrintPoints()
        {
            //path of file
            string path = Application.dataPath + "/Player.txt";
            //create file if nonexistent
            if(!File.Exists(path))
            {
                File.WriteAllText(path, "The player blob visited these random coordinates: \n\n");
            }
            foreach(Vector3 vector in v)
            {
                File.AppendAllText(path, "(" + vector.x + ", " + vector.y + ", " + vector.z + ")\n\n");
            }
        }
        float RandomNum(float lastRandNum)
        {
            //Random value range can be changed in the future if necessary
            float randNum = Random.Range(-10.0f, 10.0f);
            return System.Math.Abs(randNum - lastRandNum) < double.Epsilon ? RandomNum(randNum) : randNum;
        }
    }
