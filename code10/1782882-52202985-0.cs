    if (gameSelectionViewModel.selectedGame === '' || gameSelectionViewModel.selectedRtpLevel === '')
                    return;
    
              
              var newgame = {Name:gameSelectionViewModel.get("selectedGame"), Level:gameSelectionViewModel.get("selectedRtpLevel")}; 
              
              var filteredList = gameSelectionViewModel.get("selectedGames").data().filter(function(item){
                return item.Level === newgame.Level &&  item.Name === newgame.Name;
              }); 
              
              console.log(filteredList); 
              
              if(newgame && (filteredList === undefined || filteredList.length === 0))
              {
                 gameSelectionViewModel.selectedGames.add(newgame); 
              }
              else 
              {
                alert('game already added'); 
              }
                   
