            using (var poolDbContext = new PoolContext())
            {
                if (poolDbContext.Questions.Count() == 0)
                {
                    Question Q = new Question();
                    Q.Text = "O triunfo do FC Porto frente ao Benfica arrumou de vez as contas do título?";
                    Q.Answers.Add(new Answer { Answers = "Sim, o FC Porto vai ser campeão." });
                    Q.Answers.Add(new Answer { Answers = "Não, o Benfica ainda tem uma palavra a dizer." });
                    Q.Answers.Add(new Answer { Answers = "Não, o Sporting ainda vai ser campeão." });
                   Q.Answers.Add(new Answer { Answers = "Não ligo a futebol." });
                    poolDbContext.Questions.Add(Q);
                    var count = poolDbContext.SaveChanges();
                }
            }
            return View();
