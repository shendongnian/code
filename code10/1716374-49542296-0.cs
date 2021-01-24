    // Update is called once per frame
		void Update () {
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				playerMoney = playerMoney + 10;
				SetPlayerMoney(playerMoney);
				
				//Debug.Log("Se cambio el numero de dinero!");
			}
		}
