        class Aluno
        {
            public int matAluno { get; set; }
            public string nomeAluno { get; set; }
            public string cpfAluno { get; set; }
            public string turmaAluno { get; set; }
            public int numFaltas { get; set; }
        }
        static void Main(string[] args)
        {
            var alunosMatriculados = new List<Aluno>();
            alunosMatriculados.Add(new Aluno { matAluno = 2, nomeAluno = "MARIANA DA SILVA", cpfAluno = "111.111.111-12", turmaAluno = "2I", numFaltas = 0 });
            alunosMatriculados.Add(new Aluno { matAluno = 3, nomeAluno = "ANA MARIA SILVEIRA", cpfAluno = "111.111.111-13", turmaAluno = "1H", numFaltas = 5 });
            alunosMatriculados.Add(new Aluno { matAluno = 4, nomeAluno = "ROBERTO LINS", cpfAluno = "111.111.111-14", turmaAluno = "3H", numFaltas = 1 });
            foreach(var aluno in FindByName(alunosMatriculados, "SIL"))
            {
                Console.WriteLine(aluno.nomeAluno);
            }
            Console.ReadLine();
        }
        static IEnumerable<Aluno> FindByName( IEnumerable<Aluno> alunos, string partOfName )
        {
            //TODO error handling 
            //TODO use brazilian culture, if needed
            return  alunos
                .Where(a => !string.IsNullOrEmpty(a.nomeAluno))
                .Where(a => a.nomeAluno.Contains(partOfName));
        }
        static Aluno FindFirstByName(IEnumerable<Aluno> alunos, string name)
        {
            return FindByName(alunos, name)?.FirstOrDefault();
        }
