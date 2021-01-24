    var selection = new EliteSelection();
            var crossover = new OnePointCrossover(0);
            var mutation = new UniformMutation(true);
            var fitness = new TeamFitness(players, startTeamValue);
            var chromosome = new TeamChromosome(15, players.Count);
            var population = new Population(players.Count, players.Count, chromosome);
            var ga = new GeneticAlgorithm(population, fitness, selection, crossover, mutation)
            {
                Termination = new GenerationNumberTermination(100)
            };
            ga.Start();
            var bestChromosome = ga.BestChromosome as TeamChromosome;
            var team = new List<Player>();
            if (bestChromosome != null)
            {
                for (int i = 0; i < bestChromosome.Length; i++)
                {
                    team.Add(players[(int) bestChromosome.GetGene(i).Value]);
                }
                // Remove assigned player to avoid duplicate assignment
                players.RemoveAll(p => team.Contains(p));
                return Result<List<Player>>.Ok(team);
            }
            return Result<List<Player>>.Error("Chromosome was null!");
