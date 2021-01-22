cs
using System;
using UnityEngine;
using UnityEngine.Assertions;
namespace TL7.Stats
{
    [CreateAssetMenu(fileName = "Progression", menuName = "TL7/Stats/New Progression", order = 0)]
    public class Progression : ScriptableObject
    {
        // Provides access to characterClass only to outer class Progression
        protected interface IProgressionClassAccess
        {
            CharacterClass CharacterClass { get; set; }
        }
        [System.Serializable]
        public struct ProgressionClass : IProgressionClassAccess
        {
            [Header("DO NOT CHANGE THIS VALUE.")]
            private CharacterClass characterClass;
            [Tooltip("Levels are 0 indexed.")]
            public float[] healthOverLevels;
            CharacterClass IProgressionClassAccess.CharacterClass
            {
                get => characterClass;
                set => characterClass = value;
            }
        }
        static readonly Array characterClasses = Enum.GetValues(typeof(CharacterClass));
        [SerializeField] ProgressionClass[] classes = new ProgressionClass[characterClasses.Length];
        public ProgressionClass this[in CharacterClass index] => classes[(int)index];
        void Awake()
        {
            for (int i = 0; i < @classes.Length; ++i)
            {
                // Needs to be cast to obtain access
                (classes[i] as IProgressionClassAccess).CharacterClass = (CharacterClass)characterClasses.GetValue(i);
            }
        }
#if UNITY_EDITOR
        public void AssertCorrectSetup()
        {
            for (int i = 0; i < characterClasses.Length; ++i)
            {
                CharacterClass characterClass = (CharacterClass)characterClasses.GetValue(i);
                Assert.IsTrue(
                    (this[characterClass] as IProgressionClassAccess).CharacterClass == characterClass,
                    $"You messed with the class values in {GetType()} '{name}'. This won't do."
                );
            }
        }
#endif
    }
}
I think this only works for nested classes. In case you want to do this with regular classes, you'd need to nest them inside a partial outer class, which should work in theory, and use a `protected` or `private` nested interface (or two, if you're inclined) for providing them access to each other's privates... that came out wrong.
