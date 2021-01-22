    namespace Kannon.State
    {
        /// <summary>
        /// ReferenceDefinition describes the layout of the reference in general.
        /// It tells what states it should have, and stores the stream buffers for later serialization.
        /// </summary>
        [ProtoBuf.ProtoContract]
        public class ReferenceDefinition
        {
            /// <summary>
            /// There are several built in state types, as well as rudimentary support for a "Generic" state.
            /// </summary>
            public enum StateType
            {
                Graphics=0,
                Audio,
                Mind,
                Physics,
                Network,
                Generic
            }
            /// <summary>
            /// Represents what states should be present in the ReferenceDefinition
            /// </summary>
            [ProtoBuf.ProtoMember(1)]
            List<StateType> m_StatesPresent = new List<StateType>();
            /// <summary>
            /// Represent a list of StateDefinitions, which hold the buffers for each different type of state.
            /// </summary>
            [ProtoBuf.ProtoMember(2)]
            List<StateDefinition> m_StateDefinition = new List<StateDefinition>();
            /// <summary>
            /// Add a state, mapped to a type, to this reference definition.
            /// </summary>
            /// <param name="type">Type of state to add</param>
            /// <param name="def">State definition to add.</param>
            public void AddState(StateType type, StateDefinition def)
            {
                // Enforce only 1 of each type, except for Generic, which can have as many as it wants.
                if (m_StatesPresent.Contains(type) && type != StateType.Generic)
                    return;
                m_StatesPresent.Add(type);
                m_StateDefinition.Add(def);
            }
        }
        /// <summary>
        /// Represents a definition of some gamestate, storing protobuffered data to be remapped to the state.
        /// </summary>
        [ProtoBuf.ProtoContract]
        public class StateDefinition
        {
            /// <summary>
            /// Name of the state
            /// </summary>
            [ProtoBuf.ProtoMember(1)]
            string m_StateName;
            /// <summary>
            /// Byte array to store the "data" for later serialization.
            /// </summary>
            [ProtoBuf.ProtoMember(2)]
            byte[] m_Buffer;
            /// <summary>
            /// Constructor for the state definition, protected to enforce the Pack and Unpack functionality to keep things safe.
            /// </summary>
            /// <param name="name">Name of the state type.</param>
            /// <param name="buff">byte buffer to build state off of</param>
            protected StateDefinition(String name, byte[] buff)
            {
                m_StateName = name;
                m_Buffer = buff;
            }
            /// <summary>
            /// Unpack a StateDefinition into a GameState
            /// </summary>
            /// <typeparam name="T">Gamestate type to unpack into.  Must define Protobuf Contracts.</typeparam>
            /// <param name="def">State Definition to unpack.</param>
            /// <returns>The unpacked state data.</returns>
            public static T Unpack<T>(StateDefinition def) where T:GameState
            {
                // Make sure we're unpacking into the right state type.
                if (typeof(T).Name == def.m_StateName)
                    return ProtoBuf.Serializer.Deserialize<T>(new MemoryStream(def.m_Buffer));
                else
                    // Otherwise, return the equivalent of Null.
                    return default(T);
            }
            /// <summary>
            /// Pack a state type into a State Definition
            /// </summary>
            /// <typeparam name="T">Gamestate to package up.  Upst define protobuf contracts.</typeparam>
            /// <param name="state">State to pack up.</param>
            /// <returns>A state definition serialized from the passed in state.</returns>
            public static StateDefinition Pack<T>(T state) where T:GameState
            {
                // Using a memory stream, to make sure Garbage Collection knows what's going on.
                using (MemoryStream s = new MemoryStream())
                {
                    ProtoBuf.Serializer.Serialize<T>(s, state);
                    // Uses typeof(T).Name to do semi-enforcement of type safety.  Not the best, but it works.
                    return new StateDefinition(typeof(T).Name, s.ToArray());
                }
            }
        }
    }
