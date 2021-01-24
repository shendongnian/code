	public class QuizScript : MonoBehavior {
		public Dictionary<Outcome, int> Outcomes = new Dictionary<Outcome, int>() {
			{ Outcome.Snake, 0 },
			{ Outcome.Centipede, 0 }
		};
		public void Q2C1() {
			Outcomes[Outcome.Snake]++;
			Debug.Log("Snake: " + Outcomes[Outcome.Snake]);
		}
		public void Q3C1() {
			Outcomes[Outcome.Centipede]++;
			Debug.Log("Centipede: " + Outcomes[Outcome.Centipede]);
		}
		public Outcome GetHighestOutcome() {
            // Order by the 'key' of the dictionary, i.e. the number we tied to the outcome
			return Outcomes.OrderByDescending(choice => choice.Value).FirstOrDefault().Key;
		}
	}
	public enum Outcome {
		Snake,
		Centipede
	}
