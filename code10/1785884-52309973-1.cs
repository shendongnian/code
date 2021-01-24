    public class MyClass {
        private List<int> PreList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private List<int> ButtonList = new List<int>();
        private List<int> UserList = new List<int>();
        void Randomizer() {
            while (PreList.Count > 0 ) {
                var idx = UnityEngine.Random.Range(0, PreList.Count); // Randomly select from remaining items
                var value = PreList[idx]; // Get item value
                PreList.RemoveAt(idx); // Remove item from future options
                ButtonList.Add(value); // Add to end of 'randomised' list
            }
            foreach (var value in ButtonList) {
                DoSomethingWith(value);
            }
        }
        void DoSomethingWith(int value) {
            switch(value) {
                case 1: OneMethod(); break;
                case 2: TwoMethod(); break;
                case 3: ThreeMethod(); break;
                case 4: FourMethod(); break;
                case 5: FiveMethod(); break;
                case 6: SixMethod(); break;
                case 7: SevenMethod(); break;
                case 8: EightMethod(); break;
                case 9: NineMethod(); break;
            }
        }
    }
