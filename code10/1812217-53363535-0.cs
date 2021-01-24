    public class GameControl : MonoBehaviour
    {
        //Change YourItemType to whatver your item1, item2, item3 types are
        YourItemType item1, item2, item3;
        [SerializeField]
        private GameObject someText;
        [SerializeField]
        private GameObject goodMove;
        bool oldVal1;
        bool oldVal2;
        bool oldVal3;
        // Use this for initialization
        void Start()
        {
            someText.SetActive(false);
            goodMove.SetActive(false);
            StartCoroutine(LockChecker());
        }
        IEnumerator LockChecker()
        {
            oldVal1 = item1.locked;
            oldVal2 = item2.locked;
            oldVal3 = item3.locked;
            //Run this code forever as the Update function
            while (true)
            {
                //Check if item has changed
                if (ItemChanged())
                {
                    if (item1.locked && item2.locked && item3.locked)
                    {
                        someText.SetActive(true);
                    }
                    if (item1.locked || item2.locked || item3.locked)
                    {
                        //Call the waiter function then wait for it to return
                        yield return StartCoroutine(waiter());
                    }
                }
                yield return null;
            }
        }
        bool ItemChanged()
        {
            //Check if the booelan variable changed
            if (oldVal1 != item1.locked ||
                oldVal2 != item2.locked ||
                oldVal3 != item3.locked)
            {
                //Update old values
                oldVal1 = item1.locked;
                oldVal2 = item2.locked;
                oldVal3 = item3.locked;
                return true;
            }
            return false;
        }
        IEnumerator waiter()
        {
            goodMove.SetActive(true);
            yield return new WaitForSeconds(3);
            goodMove.SetActive(false);
        }
    }
