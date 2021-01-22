    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Text;
    using ClrTest.Reflection;
    
    namespace ExceptionAnalyser
    {
        public static class ExceptionAnalyser
        {
            public static ReadOnlyCollection<Type> GetAllExceptions(MethodBase method)
            {
                var exceptionTypes = new HashSet<Type>();
                var visitedMethods = new HashSet<MethodBase>();
                GetAllExceptions(method, exceptionTypes, visitedMethods, 0);
                return exceptionTypes.ToList().AsReadOnly();
            }
    
            public static void GetAllExceptions(MethodBase method, HashSet<Type> exceptionTypes,
                HashSet<MethodBase> visitedMethods, int depth)
            {
                var ilReader = new ILReader(method);
                var allInstructions = ilReader.ToArray();
    
                var localVars = new Type[255];
                var stack = new Stack<Type>();
                ILInstruction instruction;
                for (int i = 0; i < allInstructions.Length; i++)
                {
                    instruction = allInstructions[i];
                    if (instruction is InlineMethodInstruction)
                    {
                        var methodInstruction = (InlineMethodInstruction)instruction;
                        var curMethod = methodInstruction.Method;
                        if (curMethod is ConstructorInfo)
                            stack.Push(((ConstructorInfo)curMethod).DeclaringType);
                        else if (method is MethodInfo)
                            stack.Push(((MethodInfo)curMethod).ReturnParameter.ParameterType);
    
                        if (!visitedMethods.Contains(methodInstruction.Method))
                        {
                            visitedMethods.Add(methodInstruction.Method);
                            GetAllExceptions(methodInstruction.Method, exceptionTypes, visitedMethods,
                                depth + 1);
                        }
                    }
                    else if (instruction is InlineFieldInstruction)
                    {
                        var fieldInstruction = (InlineFieldInstruction)instruction;
                        stack.Push(fieldInstruction.Field.FieldType);
                    }
                    else if (instruction is ShortInlineBrTargetInstruction)
                    {
                        //
                    }
                    else if (instruction is InlineBrTargetInstruction)
                    {
                        //
                    }
                    else
                    {
                        switch (instruction.OpCode.Value)
                        {
                            case 0x06:
                                stack.Push(localVars[0]);
                                break;
                            case 0x07:
                                stack.Push(localVars[1]);
                                break;
                            case 0x08:
                                stack.Push(localVars[2]);
                                break;
                            case 0x09:
                                stack.Push(localVars[3]);
                                break;
                            case 0x0A:
                                localVars[0] = stack.Pop();
                                break;
                            case 0x0B:
                                localVars[1] = stack.Pop();
                                break;
                            case 0x0C:
                                localVars[2] = stack.Pop();
                                break;
                            case 0x0D:
                                localVars[3] = stack.Pop();
                                break;
                            case 0x11:
                                {
                                    int index = allInstructions[i + 1].OpCode.Value;
                                    stack.Push(localVars[index]);
                                    break;
                                }
                            case 0x13:
                                {
                                    int index = allInstructions[i + 1].OpCode.Value;
                                    localVars[index] = stack.Pop();
                                    break;
                                }
                            case 0x7A: // throw
                                exceptionTypes.Add(stack.Pop());
                                break;
                        }
                    }
                }
            }
        }
    }
