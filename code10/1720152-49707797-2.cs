	private const string PointTag = "Point";
	private int _triggerCount;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == PointTag)
		{
			bool firstCollision = (_triggerCount == 0);
			if (firstCollision)
			{
				score++;
				scoreText.text = score.ToString();
			}
			_triggerCount++;
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == PointTag)
		{
			_triggerCount--;
		}
	}
