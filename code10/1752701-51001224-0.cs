        public async Task<string> ValidateDataAsync(MyData MyData)
        {            
           var task1 = Task<MyData>.Factory.StartNew(() => MyRepository.getProfileOne());
           var task2 = Task<MyData>.Factory.StartNew(() => MyRepository.getProfileTwo());
           
           await Task.WhenAll(task1, task2)       
    
           //Update some property of MyDataOne on basis of MyDataTwo and return true or fasle in variable **result**
            return result;
        }
