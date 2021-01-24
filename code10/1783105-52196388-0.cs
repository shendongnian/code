    public void TryEvolveCharacter(IEvolvable evolvable){
            if (evolvable.Level > 10) {
                evolvable.IncreaseEvolution(1);
                ..Maybe do something new that the IEvolvable just exposed but without changing our consumed interface!
            }
    }
