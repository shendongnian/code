    public String EncontrarMenorCaminho(Vertice o, Vertice d)
            {
                Dictionary<Vertice, bool> visited = new Dictionary<Vertice, bool>();
                Dictionary<Vertice, Vertice> previous = new Dictionary<Vertice, Vertice>();
                Queue<Vertice> worklist = new Queue<Vertice>();
                String operacao = "Registro de operações realizadas:\r\n\r\n";
    
                visited.Add(o, false);
                worklist.Enqueue(o);
                while (worklist.Count != 0)
                {
                    Vertice v = worklist.Dequeue();
                    foreach (Vertice neighbor in EncontrarVizinhos(v))
                    {
                        if (!visited.ContainsKey(neighbor))
                        {
                            visited.Add(neighbor, false);
                            previous.Add(neighbor, v);
                            worklist.Enqueue(neighbor);
                        }
                    }
                }
    
                if (previous.Count > 0)
                {
                    for (int p = 0; p < previous.Count; p++)
                    {
                        Vertice v1 = previous.ElementAt(p).Key;
                        Vertice v2 = previous.ElementAt(p).Value;
                        EncontrarAresta(v1, v2).Selecionado = true;
                        EncontrarAresta(v2, v1).Selecionado = true;
                        operacao += v1.Info.ToString() + "x" + v2.Info.ToString() + "\r\n";
                    }
                }
    
                List<Vertice> grupos = new List<Vertice>();
    
                foreach (Aresta a in ArestasSelecionadas())
                {
                    if (!grupos.Contains(a.Origem)) grupos.Add(a.Origem);
                }
    
                foreach (Vertice v in grupos)
                {
                    int menorpeso = this.infinito;
                    foreach(Vertice vz in EncontrarVizinhos(v))
                    {
                        Aresta tmp = EncontrarAresta(v,vz);
                        if (tmp.Selecionado == true && tmp.Peso < menorpeso)
                        {
                            menorpeso = tmp.Peso;
                        }
                        else
                        {
                            tmp.Selecionado = false;
                        }
                    }
    
                }
    
                
    
    
                DesenharMapa();
    
                return operacao;
