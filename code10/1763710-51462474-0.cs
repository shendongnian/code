    If(!string.IsNullOrEmpty(inputName))
    {     
        foreach(Aluno a in alunosMatriculados)
        {
         If(a.nomeAluno == inputName)
          { 
              a.numFaltas = inputValue;
          }
        }
    }
