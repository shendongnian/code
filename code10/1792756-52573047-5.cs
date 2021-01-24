    using UnityEngine;
    using UnityEditor;
    
    [CustomEditor(typeof(ClasseTest))]
    public class TestCustomInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            ClasseTest script = (ClasseTest)target;
    
            script.NumMissoes = EditorGUILayout.IntField("Numero de Missoes", script.NumMissoes);
            // Ensure it cannot go into negative numbers.
            if (script.NumMissoes < 0) script.NumMissoes = 0;
    
            // numMissoes being greater than the current count means we need to extend the list.
            if (script.NumMissoes > script.MissoesJogasso.Count)
            {
                for (int i = 0; i < script.NumMissoes; i++)
                {
                    script.MissoesJogasso.Add(new ClasseTest.Missoes());
                }
            }
            // numMissoes being less than the current count means we need to decrease the list.
            else if(script.NumMissoes < script.MissoesJogasso.Count)
            {
                int difference = script.MissoesJogasso.Count - script.NumMissoes;
    
                // Remove the last element difference number of times.
                for (int i = 0; i < difference; i++)
                {
                    script.MissoesJogasso.RemoveAt(script.MissoesJogasso.Count - 1);
                }
            }
                
            for (int i = 0; i < script.MissoesJogasso.Count; i++)
            {
                var missoes = script.MissoesJogasso[i];
    
                switch(missoes.TiposMissoes)
                {
                    case ClasseTest.TiposDeMissoes.TipoMatarGente:
                        missoes.TiposMissoes = (ClasseTest.TiposDeMissoes)EditorGUILayout.EnumPopup("Matar Gentes", missoes.TiposMissoes);
                        break;
    
                    case ClasseTest.TiposDeMissoes.TipoPegarItem:
                        missoes.TiposMissoes = (ClasseTest.TiposDeMissoes)EditorGUILayout.EnumPopup("Pegar Item", missoes.TiposMissoes);
                        break;
                }
            }
        }
    }
