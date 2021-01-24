    SearchRepositoriesRequest request;
        public async Task<string> SearchReposit(string searchQuery_str, string lang_str, bool null_flg)
                {
                    //SearchRepositoriesRequest request = new SearchRepositoriesRequest();
                    // Поиск по "Реозитариям"
                    // if (request == null) // ошб
                    if (null_flg == false)
                    {
                         request = new SearchRepositoriesRequest(searchQuery_str); // mvc client side framework - Структура клиентской стороны mvc           
                        // return request; 
                    }
    
                    switch (lang_str)
                    {
                       case "C#":
                           request.Language = Language.CSharp;
                           break;                
                    }
    
                    var resultRepo = await client.Search.SearchRepo(request);
    
                    // Количество репозитариев
                    decimal countRepo_dec = Convert.ToDecimal(resultRepo.TotalCount);
    
                    // Количество репозитариев. Форматирование
                    string countRepo_str = formatValue(countRepo_dec);
    
                    return countRepo_str;            
                }
    
    
        private async void button1_Click(object sender, EventArgs e)
                {
                    // Получаем поисковую фразу
                    string searchQuery_str = Search_txB.Text;
                    string lang_str;
                    bool null_flg;
    
    
                    // Поиск по репозитариям. "Результат"
                    lang_str = "";
                    null_flg = false;
                    var countRepo = await SearchReposit(searchQuery_str, lang_str, null_flg);
                    null_flg = true;
    
                    label5.Text = countRepo;
    
                    // Поиск по репозитариям. "Результат"            
                    lang_str = "C#";
                    var countRepoLang = await SearchReposit(searchQuery_str, lang_str, null_flg);
    
                    label7.Text = countRepoLang;
    
                }
