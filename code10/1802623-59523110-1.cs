        email_arrayList = new ArrayList();
        var currentUser = FirebaseAuth.DefaultInstance.CurrentUser;
        int rank = 0;
         playerId = currentUser.UserId;
         Debug.Log(playerId);
        FirebaseDatabase.DefaultInstance.GetReference("users").ValueChanged += FirebaseSaveLoadScript_ValueChanged;
        FirebaseDatabase.DefaultInstance
          .GetReference("users").OrderByChild("userScore")
          .ValueChanged += (object sender2, ValueChangedEventArgs e2) => {
              if (e2.DatabaseError != null)
              {
                  Debug.LogError(e2.DatabaseError.Message);
                  return;
              }
              Debug.Log("Received values for Leaders.");
              string title = leaderBoard[0].ToString();
              leaderBoard.Clear();
              leaderBoard.Add(title);
              if (e2.Snapshot != null && e2.Snapshot.ChildrenCount > 0)
              {
                  foreach (var childSnapshot in e2.Snapshot.Children)
                  {
                      if (childSnapshot.Child("userScore") == null
                    || childSnapshot.Child("userScore").Value == null)
                      {
                          Debug.LogError("Bad data in sample.  Did you forget to call SetEditorDatabaseUrl with your project id?");
                          break;
                      }
                      else
                      {
                          Debug.Log("Leaders entry : " +
                        childSnapshot.Child("userEmail").Value.ToString() + " - " +
                        childSnapshot.Child("userScore").Value.ToString());
                          email_arrayList.Add(childSnapshot.Child("userEmail").Value.ToString());
                          leaderBoard.Insert(1, childSnapshot.Child("userScore").Value.ToString()
                        + "  " + childSnapshot.Child("userEmail").Value.ToString());
                          displayScores.text = "";
                          foreach (string item in leaderBoard)
                          {
                              displayScores.text += "\n" + item;
                          }
                      }
                     
                  }
              }
              email_arrayList.Reverse();
              foreach (string obj in email_arrayList)
              {
                  rank++;
                  if (obj == currentUser.Email)
                  {
                      int rank_final = rank;
                      Debug.Log("I'm number " + rank_final + " in the rankings");
                      userRank.text = "Your Rank is " + rank_final;
                      rank = 0;
                      break;
                  }
                  Debug.Log(obj);
              }
                 
          };
        
